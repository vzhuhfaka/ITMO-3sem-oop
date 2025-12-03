class OnlineCourse : Course
{
    public string MeetingLink {get; set;}

    public OnlineCourse (int courseCode, string name, string meetingLink) : base(courseCode, name)
    {
        MeetingLink = meetingLink;
    }
}