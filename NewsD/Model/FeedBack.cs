using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsFeedDAL_EF.Model
{
    public class FeedBack
    {
        public int Id { get; set; }
        public bool Islike { get; set; }
        public string Comment { get; set; }

        private DateTime? _dateNow;
        [Required]
        public DateTime CreatedDate
        {
            get
            {
                if (_dateNow == null)
                {
                    _dateNow = DateTime.Now;
                }
                return _dateNow.Value;
            }
            private set
            {
                _dateNow = value;
            }
        }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ArticleId { get; set; }
    }
}
