namespace BookShopBE.Common.Constants
{
    public class ErrorDetails
    {
        public const string MODEL_IS_NULL = "Model is null";
        public const string MODEL_IS_INVALID = "Model is invalid";

        public const string CONFIRM_PASSWORD_IS_NOT_MATCH_WITH_PASSWORD = "Confirm password is not match with password";
        public const string INCORRECT_CREDENTIALS = "User's credentials are not incorrect";
        public const string PASSWORD_IS_INVALID = "Password must have at least 6 characters; starting with a capital letter; including letters, numbers and 1 special character such as @, …";

        public const string BOOK_ID_DOES_NOT_EXIST = "Book id does not exist";
        public const string BOOK_QUANTITY_IS_NOT_ENOUGH = "The number of books in stock is not enough";

        public const string CUSTOMER_DOES_NOT_EXIST = "Customer does not exist";
        public const string CUSTOMER_HAS_NO_ORDER = "Customer has no order";

        public const string CUSTOMER_CART_IS_EMPTY = "Customer's cart is empty";
        public const string CART_ID_DOES_NOT_EXIST = "Cart id does not exist";

        public const string ORDER_ID_DOES_NOT_EXIST = "Order id does not exist";
        public const string ORDER_LIST_IS_EMPTY = "Order list is empty";

        public const string FEEDBACK_ID_DOES_NOT_EXIST = "Feedback id does not exist";
        public const string NO_FEEDBACK_FOR_BOOK = "There is no feedback for book";

        public const string USERNAME_OR_PASSWORD_IS_INVALID = "Username or password is invalid";
        public const string USERNAME_DOES_NOT_EXIST = "Username does not exist";
        public const string USER_ID_DOES_NOT_EXIST = "User id does not exist";
        public const string USERNAME_HAS_ALREADY_USED = "Username has already used";
        public const string USER_EMAIL_HAS_ALREADY_EXISTED = "User email has already existed";
        public const string NO_USER_WITH_TOKEN = "There is no user with token";
        public const string CREATE_USER_FAILED = "Create user failed";

        public const string TOKEN_IS_NOLONGER_ACTIVE = "Token is no longer active";
        public const string TOKEN_IS_NULL = "Token is null";

        public const string ROLE_DOES_NOT_EXIST = "Role does not exist";
    }
}
