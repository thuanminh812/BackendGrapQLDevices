using APIGGGDevices.Models;

namespace APIGGGDevices.GraphQL.AudioGroupQL
#nullable disable
{
    [ExtendObjectType("Mutation")]
    public class AudioGroupMutation
    {
        public async Task<AudioGroup> AddAudio([Service] GGGDevicesContext context, AudioGroup audioGroup)
        {
            var add = new AudioGroup
            {
                Name = audioGroup.Name,
                Creator = audioGroup.Creator,
                CreatedAt = DateTime.Now,
                UserId = audioGroup.UserId,
                DataNumber = audioGroup.DataNumber,
                FileNumber = audioGroup.FileNumber,
                AudioPlaylist = audioGroup.AudioPlaylist,
                TimeNumber = audioGroup.TimeNumber,
                UpdateAt = DateTime.Now,
            };
            context.AudioGroups.Add(add);
            await context.SaveChangesAsync();
            return add;
        }
        public async Task<AudioGroup> UpdateAudio([Service] GGGDevicesContext context, AudioGroup audioGroupupdate)
        {
            if(audioGroupupdate.Id > 0)
            {
                var audio = context.AudioGroups.Where(x => x.Id == audioGroupupdate.Id).FirstOrDefault();
                audio.Name = audioGroupupdate.Name;
                audio.Creator = audioGroupupdate.Creator;
                audio.CreatedAt = DateTime.Now;
                audio.UserId = audioGroupupdate.UserId;
                audio.DataNumber = audioGroupupdate.DataNumber;
                audio.FileNumber = audioGroupupdate.FileNumber;
                audio.AudioPlaylist = audioGroupupdate.AudioPlaylist;
                audio.TimeNumber = audioGroupupdate.TimeNumber;
                audio.UpdateAt = DateTime.Now;
                context.Update(audio);
                await context.SaveChangesAsync();
                return audio;
            }
            else
            {
                return audioGroupupdate;
            }

        }
        public async Task<AudioGroup> DeleteAudio([Service] GGGDevicesContext context, int idaudio)
        {
            var id = context.AudioGroups.Find(idaudio);
            context.AudioGroups.Remove(id);
            await context.SaveChangesAsync();
            return id;
        }
    }
}
