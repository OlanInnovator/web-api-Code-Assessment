using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsFeedDAL_EF.Model
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Body { get; set; }
        public string ImageUrl { get; set; }

        private DateTime? _crDateNow;
        [Required]
        public DateTime CreatedDate
        {
            get
            {
                if (_crDateNow == null)
                {
                    _crDateNow = DateTime.Now;
                }
                return _crDateNow.Value;
            }
            private set
            {
                _crDateNow = value;
            }
        }

        private DateTime? _upDateNow;
        [Required]
        public DateTime UpdatedDate
        {
            get
            {
                if (_upDateNow == null)
                {
                    _upDateNow = DateTime.Now;
                }
                return _upDateNow.Value;
            }
            private set
            {
                _upDateNow = value;
            }
        }
    }
}
