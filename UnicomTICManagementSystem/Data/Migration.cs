using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Data
{
    internal class Migration
    {
        public void Create_Table()
        {
            using (var connection = DBConfig.GetConnection())
            {

                string query = @"
                                       CREATE TABLE IF NOT EXISTS Users (UserID INTEGER PRIMARY KEY,Username TEXT,Password TEXT,Role TEXT);

                                       CREATE TABLE IF NOT EXISTS Courses (CourseID INTEGER PRIMARY KEY,CourseName TEXT);

                                       CREATE TABLE IF NOT EXISTS Subjects (SubjectID INTEGER PRIMARY KEY,SubjectName TEXT,CourseID INTEGER,FOREIGN KEY(CourseID) REFERENCES Courses(CourseID));

                                       CREATE TABLE IF NOT EXISTS Students (StudentID INTEGER PRIMARY KEY, Name TEXT,CourseID INTEGER,FOREIGN KEY(CourseID) REFERENCES Courses(CourseID));

                                       CREATE TABLE IF NOT EXISTS Exams (ExamID INTEGER PRIMARY KEY,ExamName TEXT,SubjectID INTEGER,FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID));

                                       CREATE TABLE IF NOT EXISTS Marks (MarkID INTEGER PRIMARY KEY,StudentID INTEGER,ExamID INTEGER,Score INTEGER,FOREIGN KEY(StudentID) REFERENCES Students(StudentID),FOREIGN KEY(ExamID) REFERENCES Exams(ExamID));

                                       CREATE TABLE IF NOT EXISTS Rooms (RoomID INTEGER PRIMARY KEY,RoomName TEXT,RoomType TEXT);

                                       CREATE TABLE IF NOT EXISTS Timetables (TimetableID INTEGER PRIMARY KEY,SubjectID INTEGER,TimeSlot TEXT,RoomID INTEGER,FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID),FOREIGN KEY(RoomID) REFERENCES Rooms(RoomID));

                                       CREATE TABLE IF NOT EXISTS Lecturers (LecturerID INTEGER PRIMARY KEY,Name TEXT,Address TEXT,CourseID INTEGER,SubjectID INTEGER,FOREIGN KEY(CourseID) REFERENCES Courses(CourseID),FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID));

                                       CREATE TABLE IF NOT EXISTS Staffs (StaffID INTEGER PRIMARY KEY,Name TEXT,Address TEXT,JobTitle TEXT );

                                       ";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

