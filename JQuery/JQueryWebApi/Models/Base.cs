using System;

namespace JQueryWebApi.Models
{
    public abstract class Base
    {
        protected Base()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}