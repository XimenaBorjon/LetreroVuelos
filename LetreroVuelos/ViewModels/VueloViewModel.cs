using LetreroVuelos.Models;
using LetreroVuelos.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Transactions;
using System.Windows.Documents;
using System.Windows.Threading;

namespace LetreroVuelos.ViewModels
{
    public class VueloViewModel : INotifyPropertyChanged
    {
        private static System.Timers.Timer timer = new();

        VueloServices servicesvuelo = new VueloServices();

        readonly VueloServices servic = new();
        public Vuelo vuelito { get; set; }
        public VueloViewModel()
        {
            timer.Interval = 10000;
            timer.Elapsed += ActualizarTimer;
            timer.Start();
            VuelosDatos();
        }

        private async void ActualizarTimer(object? sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke(VuelosDatos);
        }

        public ObservableCollection<Vuelo> listvuelos { get; set; } = new();

        void Actualizar(string Property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        async void VuelosDatos()
        {
                listvuelos.Clear();
                var dat = await servic.GetVuelo();
                dat.ForEach(x => listvuelos.Add(x));
                Actualizar(nameof(listvuelos));
            
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
