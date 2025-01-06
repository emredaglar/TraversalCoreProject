using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfCommentDal : GenericRepository<Comment>, ICommentDal
	{
		public List<Comment> GetListCommentWithDestination()
		{

			using (var c = new Context())
			{
				return c.Comments.Include(x => x.Destination).ToList();
			}

		}

		public List<Comment> GetListCommentWithDestinationAndUser(int id)
		{
			using (var c = new Context())
			{
				return c.Comments.Where(x=>x.DestinationId==id).Include(x => x.Destination).Include(x => x.AppUser).ToList();
			}
		}
		public Comment GetComment(int id)
		{
			using (var context = new Context())
			{
				return context.Comments
					.Include(c => c.AppUser)       // Kullanıcı bilgilerini dahil et
					.Include(c => c.Destination)  // Destinasyon bilgilerini dahil et
					.FirstOrDefault(c => c.CommentId == id);
			}
		}
		public List<Comment> GetListCommentWithUser(int userId)
		{
			using (var c = new Context())
			{
				return c.Comments.Where(x => x.AppUserId == userId)  
								 .Include(x => x.Destination)       
								 .Include(x => x.AppUser)          
								 .ToList();
			}
		}
	}
}
