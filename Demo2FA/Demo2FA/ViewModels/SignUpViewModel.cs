using System.Windows.Input;
using System.Threading.Tasks;

using Demo2FA.Models;
using Demo2FA.Services;

using Xamarin.Forms;

namespace Demo2FA.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        private CompanyUser _companyUser;

        public CompanyUser CompanyUser
        {
            get { return _companyUser; }
            set { _companyUser = value; OnPropertyChanged(); }
        }

        private AuthyUserResponse _authyUserResponse;

        public AuthyUserResponse AuthyUserResponse
        {
            get { return _authyUserResponse; }
            set { _authyUserResponse = value; OnPropertyChanged(); }
        }

        private AuthyOTPResponse _authyOTPResponse;

        public AuthyOTPResponse AuthyOTPResponse
        {
            get { return _authyOTPResponse; }
            set { _authyOTPResponse = value; OnPropertyChanged(); }
        }

        private AuthyVerifyResponse _authyVerifyResponse;

        public AuthyVerifyResponse AuthyVerifyResponse
        {
            get { return _authyVerifyResponse; }
            set { _authyVerifyResponse = value; OnPropertyChanged(); }
        }

        private long _token;

        public long Token
        {
            get { return _token; }
            set { _token = value; OnPropertyChanged(); }
        }

        private bool _needsVerification;

        public bool NeedsVerification
        {
            get { return _needsVerification; }
            set { _needsVerification = value; OnPropertyChanged(); }
        }

        public ICommand SignUpCommand { private set; get; }
        public ICommand VerifyTokenCommand { private set; get; }

        public SignUpViewModel()
        {
            SignUpCommand = new Command(async () => await SignUp());
            VerifyTokenCommand = new Command(async () => await VerifyToken());

            CompanyUser = new CompanyUser();
        }

        async Task SignUp()
        {
            AuthyUserResponse = await AuthyService.AddUser(CompanyUser);

            if (AuthyUserResponse != null)
            {
                AuthyOTPResponse = await AuthyService.SendOTP(AuthyUserResponse.User.Id);

                if (AuthyOTPResponse != null)
                    NeedsVerification = AuthyOTPResponse.Success;
            }
        }

        async Task VerifyToken()
        {
            AuthyVerifyResponse = await AuthyService.VerifyToken(Token, AuthyUserResponse.User.Id);
        }
    }
}
