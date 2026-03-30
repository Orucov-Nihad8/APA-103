using System;

// ----------------- CUSTOM EXCEPTIONS -----------------

class InvalidUsernameException : Exception
{
    public InvalidUsernameException() : base("Username cannot be empty or less than 3 characters.") { }
    public InvalidUsernameException(string message) : base(message) { }
}

class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base("Password cannot be empty or less than 6 characters.") { }
    public InvalidPasswordException(string message) : base(message) { }
}

class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("User not found.") { }
    public UserNotFoundException(string username) : base($"User '{username}' not found.") { }
}

class IncorrectPasswordException : Exception
{
    public int AttemptsLeft { get; private set; }
    public IncorrectPasswordException(int attemptsLeft)
        : base($"Incorrect password. Attempts left: {attemptsLeft}") 
    {
        AttemptsLeft = attemptsLeft;
    }
}

class AccountLockedException : Exception
{
    public AccountLockedException() : base("Account is locked. Contact admin.") { }
}

// ----------------- USER CLASS -----------------

class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsLocked { get; set; }
    public int FailedAttempts { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
        IsLocked = false;
        FailedAttempts = 0;
    }
}

// ----------------- LOGIN SYSTEM -----------------

class LoginSystem
{
    private User[] users;
    private const int MaxAttempts = 3;

    public LoginSystem()
    {
        users = new User[]
        {
            new User("admin", "admin123"),
            new User("student", "student123"),
            new User("teacher", "teacher123")
        };
    }

    public void ValidateUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
            throw new InvalidUsernameException();
    }

    public void ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            throw new InvalidPasswordException();
    }

    private User FindUser(string username)
    {
        foreach (var user in users)
        {
            if (user.Username.ToLower() == username.ToLower())
                return user;
        }
        return null;
    }

    
