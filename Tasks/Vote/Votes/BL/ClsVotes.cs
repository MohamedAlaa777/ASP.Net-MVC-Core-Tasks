using Votes.Data;
using Votes.Models;

namespace Votes.BL
{
    public class ClsVotes
    {
        public List<Voter> GetAll()
        {
            try
            {
                VoteContext context = new VoteContext();
                var lstVotes = context.TbVotes.ToList();
                return lstVotes;
            }
            catch 
            {
                return new List<Voter>();
            }
        }

        public Voter GetById(int id) 
        {
            try
            {
                VoteContext context = new VoteContext();
                var vote = context.TbVotes.FirstOrDefault(a => a.Id == id);
                return vote;
            }
            catch
            {
                return new Voter();
            }
        }

        public bool Save(Voter voter)
        {
            try
            {
                VoteContext context = new VoteContext();
                if(voter.Id == 0) 
                {
                    context.TbVotes.Add(voter);
                }
                else
                {
                    context.Entry(voter).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                VoteContext context = new VoteContext();
                var votes = GetById(id);
                context.TbVotes.Remove(votes);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
