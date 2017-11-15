using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using MeuPonto.Base;
using Xamarin.Forms;
using SQLite.Net.Interop;

[assembly: Dependency(typeof(MeuPonto.Droid.Config))]
namespace MeuPonto.Droid
{
    public class Config : IConfig
    {
        private string diretorioSQLite;
        public string DiretorioSQLite
        {
            get
            {
                if (string.IsNullOrEmpty(diretorioSQLite))
                {
                    diretorioSQLite = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return diretorioSQLite;
            }
        }

        private ISQLitePlatform plataforma;
        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return plataforma;
            }
        }
    }
}