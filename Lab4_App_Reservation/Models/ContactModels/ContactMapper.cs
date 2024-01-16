using Data.Entities;

namespace Lab4_App_Reservation.Models.ContactModels;

public class ContactMapper
{
    public static Contact FromEntity(ContactEntity entity)
    {
        return new Contact()
        {
            Id = entity.ContactId,
            Name = entity.Name,
            Email = entity.Email,
            Phone = entity.Phone,
            Birth = entity.Birth,
            Created = entity.Created,
            Priority = entity.Priority

        };
    }

    public static ContactEntity ToEntity(Contact model)
    {
        return new ContactEntity()
        {
            ContactId = model.Id,
            Name = model.Name,
            Email = model.Email,
            Phone = model.Phone,
            Birth = model.Birth,
            Created = model.Created,
            Priority = model.Priority
        };
    }
}
