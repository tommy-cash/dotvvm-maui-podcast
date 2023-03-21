using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;

namespace DotNetPodcasts.App.Maui.HostedApp.Pages.SamplePage
{
    public class SamplePageViewModel : DotNetPodcasts.App.Maui.HostedApp.Pages.MasterPageViewModel
    {
        public int Op1 { get; set; }
        public int Op2 { get; set; }
        public int Result { get; set; }

        public void AddUp(int op1, int op2)
        {
            Result = op1 + op2;
        }
    }
}

