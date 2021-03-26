using BusinessLogic.Implementation;
using BusinessLogic.Implementation.Account;
using BusinessLogic.Implementation.Reservation;
using BusinessLogic.Interface;
using BusinessLogic.Interface.Account;
using BusinessLogic.Interface.Reservation;
using Infraestructure.Persistence.Repositories.Implementation;
using Infraestructure.Persistence.Repositories.Implementation.Account;
using Infraestructure.Persistence.Repositories.Implementation.Reservation;
using Infraestructure.Persistence.Repositories.Interface;
using Infraestructure.Persistence.Repositories.Interface.Account;
using Infraestructure.Persistence.Repositories.Interface.Reservation;
using Ninject.Modules;


namespace WEB.DI.Config
{
    public class DependencyInjectionContainer : NinjectModule
    {

        public override void Load()
        {

            //BL

            Bind<IGetFlightBL>().To<GetFlightBL>();
            Bind<IGetFlightsBL>().To<GetFlightsBL>();
            Bind<IGetUserBL>().To<GetUserBL>();
            Bind<ISaveUserBL>().To<SaveUserBL>();
            Bind<ISaveReservationBL>().To<SaveReservationBL>();

            //REPOSITORY
            Bind<IGetUserRepo>().To<GetUserRepo>();
            Bind<IGetFlightRepo>().To<GetFlightRepo>();
            Bind<IGetFlightsRepo>().To<GetFlightsRepo>();
            Bind<ISaveUserRepo>().To<SaveUserRepo>();
            Bind<ISaveReservationRepo>().To<SaveReservationRepo>();



            //Bind<IValidationsFileContentBL>().To<ValidationsFileContentBL>();

            //Bind<IOperationsFileUploadBL>().To<OperationsFileUploadBL>();

            //////dependency injection  Utitlities
            //Bind(typeof(IToolsFileUpload)).To(typeof(ToolsFileUpload)).InSingletonScope();

        }
    }
}