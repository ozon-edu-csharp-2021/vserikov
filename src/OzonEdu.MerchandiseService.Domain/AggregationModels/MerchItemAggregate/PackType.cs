using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class PackType : Enumeration
    {
        public static PackType DefaultPack = new(0, nameof(DefaultPack));

        /// <summary>
        /// выдается сотруднику, только вышедшему на работу
        /// </summary>
        public static PackType WelcomePack = new(1, nameof(WelcomePack));

        /// <summary>
        /// выдается сотруднику, прошедшему испытательный срок
        /// </summary>
        public static PackType StarterPack = new(2, nameof(StarterPack));

        /// <summary>
        /// выдается сотруднику, участвующему в конференции в качестве слушателя
        /// </summary>
        public static PackType ConferenceListenerPack = new(3, nameof(ConferenceListenerPack));

        /// <summary>
        /// выдается сотруднику, участвующему в конференции в качестве докладчика
        /// </summary>
        public static PackType ConferenceSpeakerPack = new(4, nameof(ConferenceSpeakerPack));

        /// <summary>
        /// выдается сотруднику, отработавшему в компании больше 5 лет
        /// </summary>
        public static PackType VeteranPack = new(5, nameof(VeteranPack));

        public PackType(int id, string name) : base(id, name)
        {
        }

        public static PackType GetPackTypeById(int id)
        {
            return id switch
            {
                1 => WelcomePack,
                2 => StarterPack,
                3 => ConferenceListenerPack,
                4 => ConferenceSpeakerPack,
                5 => VeteranPack,
                _ => throw new UnknownPackTypeException($"Unknown pack type with id {id}")
            };
        }
    }
}
