using NUnit.Framework;
using DoctorAppointmentAppBLLibrary;
using System.Collections.Generic;
using DoctorAppointmentAppDLLibrary;
using DoctorAppointmentAppModelLib;

[TestFixture]
public class DoctorBLTests
{
    private DoctorRepository _repo;
    private DoctorBL _doctorBL;

    [SetUp]
    public void Setup()
    {
        _repo = new DoctorRepository();
        _doctorBL = new DoctorBL(_repo);
    }

    [Test]

    public void AddDoctor_ShouldReturnDoctorId_WhenDoctorIsAdded()
    {
        // Arrange
        var doctor = new Doctor { DoctorId = 1 };

        if (_repo == null)
        {
            _repo = new DoctorRepository(); 
        }

        // Act
        if (_doctorBL == null)
        {
            _doctorBL = new DoctorBL(_repo); 
        }
        var addedDoctorId = _doctorBL.AddDoctor(doctor);

        // Assert
        Assert.AreEqual(addedDoctorId, 1);
    }

    [Test]
    public void GetDoctorById_ShouldReturnDoctor_WhenDoctorExists()
    {
        // Arrange
        var doctor = new Doctor { DoctorId = 1 };
        _repo.Add(doctor);

        // Act
        var result = _doctorBL.GetDoctorById(1);

        // Assert
        Assert.AreEqual(doctor, result);
    }

    
    [Test]
    public void UpdateDoctorDetails_ShouldReturnUpdatedDoctor_WhenDoctorExists()
    {
        // Arrange
        var doctor = new Doctor { DoctorId = 1 };
        _repo.Add(doctor);
        doctor.Name = "Updated Name";

        // Act
        var result = _doctorBL.UpdateDoctorDetails(doctor);

        // Assert
        Assert.AreEqual(doctor, result);
    }

    [Test]
    public void CheckAvailability_ShouldReturnTrue_WhenDoctorIsAvailable()
    {
        // Arrange
        var specificDateTime = DateTime.Now;
        var doctor = new Doctor { DoctorId = 1, Availability = new Dictionary<DateTime, bool> { { specificDateTime, true } } };
        _repo.Add(doctor);

        // Act
        var result = _doctorBL.CheckAvailability(1, specificDateTime);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void AddDoctor_ShouldThrowException_WhenDoctorIsNull()
    {
        // Arrange
        Doctor doctor = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _doctorBL.AddDoctor(doctor));
    }

    [Test]
    public void GetDoctorById_ShouldReturnNull_WhenDoctorDoesNotExist()
    {
        // Arrange
        int nonExistentId = 999;

        // Act
        var result = _doctorBL.GetDoctorById(nonExistentId);

        // Assert
        Assert.IsNull(result);
    }


    

    [Test]
    public void UpdateDoctorDetails_ShouldThrowException_WhenDoctorDoesNotExist()
    {
        // Arrange
        var doctor = new Doctor { DoctorId = 999 };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _doctorBL.UpdateDoctorDetails(doctor));
    }

    [Test]
    public void CheckAvailability_ShouldReturnFalse_WhenDoctorIsNotAvailable()
    {
        // Arrange
        var specificDateTime = DateTime.Now;
        var doctor = new Doctor { DoctorId = 1, Availability = new Dictionary<DateTime, bool> { { specificDateTime, false } } };
        _repo.Add(doctor);

        // Act
        var result = _doctorBL.CheckAvailability(1, specificDateTime);

        // Assert
        Assert.IsFalse(result);
    }


}