using DAL;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ListBLL
    {
        public List<MovieInfoModel> SelectMovieInfo()
        {
            return new ListDAL().SelectMovieInfo();
        }

        public List<MovieInfoModel> SelectMovieInfo2()
        {
            return new ListDAL().SelectMovieInfo2();
        }

        public List<MovieInfoModel> SelectMovieInfo3()
        {
            return new ListDAL().SelectMovieInfo3();
        }

        public List<MovieInfoModel> SelectMovieInfo4()
        {
            return new ListDAL().SelectMovieInfo4();
        }

        
    }
}