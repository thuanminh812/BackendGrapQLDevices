using APIGGGDevices.Models;
#nullable disable
namespace APIGGGDevices.GraphQL.ContentGroupQL
{
    [ExtendObjectType("Mutation")]
    public class ContentGroupMutation
    {
        public async Task<ContentGroup> AddContentGroupAsync([Service] GGGDevicesContext context, ContentGroup contentGroup)
        {
            var add = new ContentGroup
            {
                Name = contentGroup.Name,
                FileNumber = contentGroup.FileNumber,
                DataNumber = contentGroup.DataNumber,
                Creator = contentGroup.Creator,
                Playlists = contentGroup.Playlists,
                CreatedAt = DateTime.UtcNow,
                TypeLcd = contentGroup.TypeLcd,
                UserId = contentGroup.UserId,
                UpdatedAt = DateTime.UtcNow,
            };
            context.ContentGroups.Add(add);
            await context.SaveChangesAsync();
            return add;
        }
        public async Task<ContentGroup> UpdateContentGroupAsync([Service] GGGDevicesContext context, ContentGroup contentGroup)
        {
            if (contentGroup.Id > 0)
            {
                var content = context.ContentGroups.Where(x => x.Id == contentGroup.Id).FirstOrDefault();
                content.Name = contentGroup.Name;
                content.FileNumber = contentGroup.FileNumber;
                content.DataNumber = contentGroup.DataNumber;
                content.Creator = contentGroup.Creator;
                content.Playlists = contentGroup.Playlists;
                content.CreatedAt = DateTime.UtcNow;
                content.TypeLcd = contentGroup.TypeLcd;
                content.UserId = contentGroup.UserId;
                content.UpdatedAt = DateTime.UtcNow;
                context.Update(content);
                await context.SaveChangesAsync();
                return content;
            }
            else
            {
                return contentGroup;
            }
        }
        public async Task<ContentGroup> DeleteContentGroupAsync([Service] GGGDevicesContext context, int idcontent)
        {
            var id = context.ContentGroups.Find(idcontent);
            context.ContentGroups.Remove(id);
            await context.SaveChangesAsync();
            return id;

        }
    }
}
