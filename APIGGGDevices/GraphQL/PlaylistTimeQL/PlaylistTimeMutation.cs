using APIGGGDevices.Models;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace APIGGGDevices.GraphQL.PlaylistTimeQL
{
    [ExtendObjectType("Mutation")]
    public class PlaylistTimeMutation
    {
        public async Task<PlaylistTime> AddPlaylistTimeAsync([Service] GGGDevicesContext context, PlaylistTime playlistTime)
        {
            var add = new PlaylistTime 
            {
                Name = playlistTime.Name,
                StartPlaylist = playlistTime.StartPlaylist,
                EndPlaylist = playlistTime.EndPlaylist,
                CreatedAt = DateTime.UtcNow,
                Creator = playlistTime.Creator,
                TypeLcd = playlistTime.TypeLcd,
                FileNumber = playlistTime.FileNumber,
                DataNumber = playlistTime.DataNumber,
                UserId = playlistTime.UserId,
                UpdatedAt = DateTime.UtcNow,
            };
            
            context.PlaylistTimes.Add(add);
            await context.SaveChangesAsync();
            return add;
        }
        public async Task<PlaylistTime> UpdatePlaylistAsync([Service]GGGDevicesContext context,PlaylistTime playlistTime)
        {
            if (playlistTime.Id > 0)
            {
                var play = context.PlaylistTimes.Where(x => x.Id == playlistTime.Id).FirstOrDefault();
                play.Name = playlistTime.Name;
                play.StartPlaylist = playlistTime.StartPlaylist;
                play.EndPlaylist = playlistTime.EndPlaylist;
                play.CreatedAt = DateTime.UtcNow;
                play.Creator = playlistTime.Creator;
                play.TypeLcd = playlistTime.TypeLcd;
                play.FileNumber = playlistTime.FileNumber;
                play.DataNumber = playlistTime.DataNumber;
                play.UserId = playlistTime.UserId;
                play.UpdatedAt = DateTime.UtcNow;
                context.Update(play);
                await context.SaveChangesAsync();
                return play;
            }
            else
            {                
                return playlistTime;
            }
        }
        public async Task<PlaylistTime> DeletePlaylistAsync([Service] GGGDevicesContext context, int idplaylist)
        {
            var id = context.PlaylistTimes.Find(idplaylist);
            context.PlaylistTimes.Remove(id);
            await context.SaveChangesAsync();
            return id;

        }
    }
}
