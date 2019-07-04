using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Data;
using MovieApp.Model;


namespace MovieApp.ViewModel
{
    public class WriteDiaryVM : BaseViewModel
    {
        public ICommand AddDiaryCommand { get; }
        string _title;

        SqlClient dataBase;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        string _content;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }
        public WriteDiaryVM()
        {
            AddDiaryCommand = new Command(InsertDiary);
            dataBase = new SqlClient();

        }

       async void InsertDiary()
        {
            try
            {
                CheckDiaryValidation();
                InsertToDiaryTable();

                await Application.Current.MainPage.DisplayAlert("저장", "저장되었습니다.", "cancel");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", "제목과 컨텐츠를 입력해주세요.", "cancel");
                return;
            }
        }

        private void CheckDiaryValidation()
        {
            if (string.IsNullOrEmpty(Title))
            {
                throw new Exception("Fill in the Title");
            }
            else if (string.IsNullOrEmpty(Content))
            {
                throw new Exception("Fill in the Content");
            }

        }

        private void InsertToDiaryTable()
        {
            try
            {
                string sql = @"insert into diary (title, content) values (@Title,@Content)";

                dataBase.SetQuery(sql, CommandType.Text);
                dataBase.AddParameter("@Title", Title);
                dataBase.AddParameter("@Content", Content);
                dataBase.ExcuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error");
            }
        }
    }
}
