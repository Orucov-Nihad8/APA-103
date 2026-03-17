using System;
using System.Collections.Generic;

// 1. Person Base Class
class Person
{
    public string FirstName;
    public string LastName;
    public int Age;
    public string Email;
    public string Id;

    public Person(string firstName, string lastName, int age, string email, string id)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Email = email;
        this.Id = id;
    }

    public string GetFullName()
    {
        return this.FirstName + " " + this.LastName;
    }

    public void ShowBasicInfo()
    {
        Console.WriteLine("ID: " + this.Id);
        Console.WriteLine("Ad Soyad: " + GetFullName());
        Console.WriteLine("Yaş: " + this.Age);
        Console.WriteLine("Email: " + this.Email);
    }
}

// 2. Student Class
class Student : Person
{
    public string StudentNumber;
    public string Faculty;
    public double GPA;
    public int Year;

    public Student(string firstName, string lastName, int age, string email, string id,
                   string studentNumber, string faculty, double gpa, int year)
        : base(firstName, lastName, age, email, id)
    {
        this.StudentNumber = studentNumber;
        this.Faculty = faculty;
        this.GPA = gpa;
        this.Year = year;
    }

    public void ShowStudentInfo()
    {
        ShowBasicInfo();
        Console.WriteLine("Tələbə Nömrəsi: " + this.StudentNumber);
        Console.WriteLine("Fakültə: " + this.Faculty);
        Console.WriteLine("Orta Bal: " + this.GPA);
        Console.WriteLine("Kurs: " + this.Year);
    }

    public double CalculateScholarship()
    {
        if (this.GPA >= 90) return 500;
        else if (this.GPA >= 80) return 350;
        else if (this.GPA >= 70) return 200;
        else return 0;
    }
}

// 3. Teacher Class
class Teacher : Person
{
    public string Department;
    public string MainSubject;
    public decimal BaseSalary;
    public int ExperienceYears;

    public Teacher(string firstName, string lastName, int age, string email, string id,
                   string department, string mainSubject, decimal baseSalary, int experienceYears)
        : base(firstName, lastName, age, email, id)
    {
        this.Department = department;
        this.MainSubject = mainSubject;
        this.BaseSalary = baseSalary;
        this.ExperienceYears = experienceYears;
    }

    public void ShowTeacherInfo()
    {
        ShowBasicInfo();
        Console.WriteLine("Kafedra: " + this.Department);
        Console.WriteLine("Əsas Fənn: " + this.MainSubject);
        Console.WriteLine("Baza Maaş: " + this.BaseSalary + " AZN");
        Console.WriteLine("Təcrübə: " + this.ExperienceYears + " il");
    }

    public decimal CalculateSalary()
    {
        return this.BaseSalary + (this.ExperienceYears * 50);
    }
}

// 4. Administrator Class
class Administrator : Person
{
    public string Position;
    public string Department;
    public int AccessLevel;

    public Administrator(string firstName, string lastName, int age, string email, string id,
                         string position, string department, int accessLevel)
        : base(firstName, lastName, age, email, id)
    {
        this.Position = position;
        this.Department = department;
        this.AccessLevel = accessLevel;
    }

    public void ShowAdminInfo()
    {
        ShowBasicInfo();
        Console.WriteLine("Vəzifə: " + this.Position);
        Console.WriteLine("Şöbə/Kafedra: " + this.Department);
        Console.WriteLine("Giriş Səviyyəsi: " + this.AccessLevel);
    }

    public void GrantAccess(Student student)
    {
        Console.WriteLine(student.GetFullName() + " tələbəsinə sistem girişi verildi!");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        // 3 Student
        Student s1 = new Student("Nihad", "Aliyev", 20, "nihad@example.com", "S001", "2023001", "Kompyuter Elmləri", 88.5, 2);
        Student s2 = new Student("Aysel", "Huseynova", 21, "aysel@example.com", "S002", "2023002", "Riyaziyyat", 92.0, 3);
        Student s3 = new Student("Elvin", "Mammadov", 19, "elvin@example.com", "S003", "2023003", "Fizika", 68.5, 1);

        List<Student> students = new List<Student> { s1, s2, s3 };
        double totalScholarship = 0;

        foreach (var s in students)
        {
            Console.WriteLine("\n--- Tələbə Məlumatları ---");
            s.ShowStudentInfo();
            double scholarship = s.CalculateScholarship();
            totalScholarship += scholarship;
            Console.WriteLine("Təqaüd: " + scholarship + " AZN");
        }

        // 2 Teacher
        Teacher t1 = new Teacher("Ramin", "Huseynov", 40, "ramin@example.com", "T001", "Kompyuter Elmləri", "Proqramlaşdırma", 800, 15);
        Teacher t2 = new Teacher("Leyla", "Sadiqova", 35, "leyla@example.com", "T002", "Riyaziyyat", "Statistika", 800, 8);

        List<Teacher> teachers = new List<Teacher> { t1, t2 };
        decimal totalSalary = 0;

        foreach (var t in teachers)
        {
            Console.WriteLine("\n--- Müəllim Məlumatları ---");
            t.ShowTeacherInfo();
            decimal salary = t.CalculateSalary();
            totalSalary += salary;
            Console.WriteLine("Maaş: " + salary + " AZN");
        }

        // Administrator
        Administrator admin = new Administrator("Fidan", "Rzayeva", 45, "fidan@example.com", "A001", "Dekan", "Kompyuter Elmləri", 5);
        Console.WriteLine("\n--- Administrator Məlumatları ---");
        admin.ShowAdminInfo();

        // Grant Access
        admin.GrantAccess(s1);

        // Statistika
        Console.WriteLine("\n--- Statistika ---");
        Console.WriteLine("Ümumi Təqaüd Xərci: " + totalScholarship + " AZN");
        Console.WriteLine("Ümumi Maaş Xərci: " + totalSalary + " AZN");
    }
}
