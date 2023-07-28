using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModpackUpdater;

public partial class UpdatePack : ContentPage
{
    public UpdatePack()
    {
        getMMCInstances();
        
        InitializeComponent();
    }

    public List<string> MMCInstances;

    public void getMMCInstances()
    {
        
    }
}