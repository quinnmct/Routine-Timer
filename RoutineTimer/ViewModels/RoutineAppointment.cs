using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace RoutineTimer.ViewModels
{
    public class RoutineAppointment : IAppointment
    {
            /// <summary> 
    /// Gets the details of the appointment. 
    /// </summary> 
    public string Details
    {
        get;
        set;
    }

    /// <summary> 
    /// Gets the end date and time of the appointment. 
    /// </summary> 
    public DateTime EndDate
    {
        get;
        set;
    }

    /// <summary> 
    /// Gets the location of the appointment. 
    /// </summary> 
    public string Location
    {
        get;
        set;
    }

    /// <summary> 
    /// Gets the start date and time of the appointment. 
    /// </summary> 
    public DateTime StartDate
    {
        get;
        set;
    }

    /// <summary> 
    /// Gets the subject of the appointment. 
    /// </summary> 
    public string Subject
    {
        get;
        set;
    }

    /// <summary> 
    /// Gets a string representation of the appointment 
    /// </summary> 
    /// <returns>A string representation of the appointment</returns> 
    public override string ToString()
    {
        return this.Subject;
    }
    }
}
