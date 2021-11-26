using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace bea_audits.COORDINATION
{
    class C_NOTIFIABLE : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Signal_changement([CallerMemberName] string P_Nom = null)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(P_Nom));
        }
    }
}
