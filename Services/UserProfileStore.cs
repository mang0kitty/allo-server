using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allo.Model;

namespace Allo.Services
{
    public class UserProfileStore : IUserProfileStore
    {
        private readonly List<UserProfile> cards = new List<UserProfile>();

        public async Task<UserProfile> GetCardAsync(string id)
        {
            return this.cards.SingleOrDefault(c => c.ID == id);
        }

        public async Task<IEnumerable<UserProfile>> GetUserCardsAsync(string email)
        {
            return this.cards.Where(card => card.Contact.Any(c => c.Type == "email" && c.Value == email));
        }

        public async Task<bool> RemoveCardAsync(string id)
        {
           var card = cards.SingleOrDefault(c => c.ID == id);
            if(card == null) {
                return false;
            }

            cards.Remove(card);
            return true;
        }

        public async Task<UserProfile> StoreCardAsync(UserProfile card)
        {
            if (card.ID == null) {
                card.ID = Guid.NewGuid().ToString("N");
            }

            var existing = this.cards.SingleOrDefault(c => c.ID == card.ID);
            if(existing == null) {
                this.cards.Add(card);
                return card;
            }

            var index = this.cards.IndexOf(existing);
            this.cards[index] = card;

            return card;
        }
    
    }
}