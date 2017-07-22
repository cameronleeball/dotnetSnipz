using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace dotnetSnipz.Models
{
    public class Snippet
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

		
		public string Desc { get; set; }


		[Required]
        public string Code { get; set; }

        [Required]
        public string Lang { get; set; }

        public static explicit operator UpdateDefinition<object>(Snippet v)
        {
            throw new NotImplementedException();
        }
    }
}
