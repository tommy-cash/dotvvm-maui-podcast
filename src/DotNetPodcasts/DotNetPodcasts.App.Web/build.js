import esbuild from 'esbuild'
import fs from 'fs'
import { sassPlugin } from 'esbuild-sass-plugin';
import postcss from 'postcss';
import autoprefixer from 'autoprefixer';
import postcssPresetEnv from 'postcss-preset-env';

const args = process.argv.slice(2);
const watch = args.includes('--watch')

//Custom watch plugin
const watchPlugin = {
    name: 'watch-plugin',
    setup(build) {
        build.onStart(() => { console.log('\x1b[0m', 'Build starting') })
        build.onEnd((result) => {
            if (result.errors.length > 0) {
                console.log('\x1b[31m', `[${new Date(Date.now()).toLocaleTimeString()}] Build finished,  with errors: ${result.errors}`)
            }
            else {
                console.log('\x1b[32m', `[${new Date(Date.now()).toLocaleTimeString()}] Build finished successfully!`)
            }
        })
    }
}

// configure project paths for auto-discovery
const inputPaths = ['./Components', './Pages', './Resources/Styles', './Resources/Scripts'];
const extensions = {
    '.ts': '.js',
    '.scss': '.css'
};
const excludedExtensions = ['.d.ts'];

// output path for generated files
const outputPath = './wwwroot';

function autoDiscoverFiles(path) {
    let targets = {};
    for (const entry of fs.readdirSync(path)) {

        const entryPath = `${path}/${entry}`;
        if (fs.lstatSync(entryPath).isDirectory()) {
            // recursive browse directory
            const childTargets = autoDiscoverFiles(entryPath);
            targets = { ...targets, ...childTargets };

        } else if (!entry.startsWith("_")
            && !excludedExtensions.some(e => hasExtension(entryPath, e))) {

            const matchedExtension = Object.keys(extensions).filter(e => hasExtension(entryPath, e))[0];
            if (matchedExtension) {
                // this is our file
                targets[entryPath] = entryPath.substring(0, entryPath.length - matchedExtension.length) + extensions[matchedExtension];
            }
        }
    }
    return targets;
}

function hasExtension(path, extension) {
    return path.toUpperCase().endsWith(extension.toUpperCase());
}

async function main() {

    // search for inputs
    let targets = {};
    for (const path of inputPaths) {
        const foundTargets = autoDiscoverFiles(path);
        targets = { ...targets, ...foundTargets };
    }

    // build
    for (const target in targets) {
        console.log('\x1b[0m', `Compiling ${target}...`);

        try {

            const context = await esbuild.context({
                format: 'esm',
                bundle: true,
                entryPoints: [target],
                outfile: `${outputPath}/${targets[target]}`,
                target: [
                    'esnext'
                ],
                sourcemap: false,
                treeShaking: false,
                minify: true,
                mangleProps: /^_/,
                plugins: [
                    sassPlugin({
                        async transform(source) {
                            const { css } = await postcss([autoprefixer, postcssPresetEnv({
                                stage: 1,
                                features: {
                                    "cascade-layers": false
                                }
                            })]).process(source, { from: undefined })
                            return css
                        }
                    }),
                    watchPlugin
                ],
                external: ['*.ttf', '*.eot', '*.eot?#iefix', '*.woff', '*.otf', '*.svg', '*.svg?#webfont', '*.jpg', '*.jpeg', '*.png', '*.webp', '*.avif']
            })

            if (watch) {
                await context.watch()
                console.log('\x1b[33m', 'Watching...')
            }
            else {
                context.rebuild()
                context.dispose()
            }
        }
        catch (err) {
            console.error('\x1b[32m', `Cannot build ${target}: ${err}`);
        }
    }
}

main();