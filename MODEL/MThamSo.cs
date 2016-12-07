﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MODEL
{
    public class MThamSo
    {
        public List<THAMSO> List(string search)
        {
            using (var db = new QLPhongKaraokeEntities())
            {
                IEnumerable<THAMSO> query = from s in db.THAMSOes select s;

                //Filter // neu de search=null thi kho search,
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => (x.Name != null &&
                                              x.Name.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                             (x.Value != null &&
                                              x.Value.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        );
                }

                return query.ToList();
            }
        }

        public bool Insert(THAMSO item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    db.THAMSOes.Add(item);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string name)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.THAMSOes
                        where s.Name == name
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        db.THAMSOes.Remove(sv);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(THAMSO item)
        {
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.THAMSOes
                        where s.Name == item.Name
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        sv.Value = item.Value;
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Get(string name)
        {
            string strx = null;
            try
            {
                using (var db = new QLPhongKaraokeEntities())
                {
                    var x = from s in db.THAMSOes
                        where s.Name == name
                        select s;
                    var sv = x.FirstOrDefault();
                    if (sv != null)
                    {
                        strx = sv.Value;
                    }
                }
                return strx;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}