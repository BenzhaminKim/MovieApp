using System;
using System.Collections.ObjectModel;
using System.Data;
using MovieApp.Model;

namespace MovieApp.ViewModel
{
    public class DiaryListVM:BaseViewModel
    {
        SqlClient DB;
        public IObservable<Diary> Diaries { get; set; }
        public DiaryListVM()
        {
           DB = new SqlClient();
        }

       ObservableCollection<Diary> GetDiaries()
        {
            string sql = @"select * from diary";
            DB.SetQuery(sql,)
            
        }
    }
}
