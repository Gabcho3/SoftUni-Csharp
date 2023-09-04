using System.ComponentModel;

namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;

        [SetUp]
        public void Setup()
        {
            device = new Device(1000);
        }


        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual(1000, device.MemoryCapacity);
            Assert.AreEqual(1000, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void Test_TakingPhotoIncraesesPhotosCountAndDecreasesMemoryAndReturn()
        {
            bool isTook = device.TakePhoto(100);
            Assert.IsTrue(isTook);
            Assert.AreEqual(1, device.Photos);
            Assert.AreEqual(900, device.AvailableMemory);
        }

        [Test]
        public void Test_CannotTakePhotoIfThereIsNoSpace()
        {
            device.TakePhoto(100);
            device.TakePhoto(400);

            bool isTook  = device.TakePhoto(600);
            Assert.IsFalse(isTook);
        }

        [Test]
        public void Test_InstallingAppDecreasesMemoryIncreasesApplicationsCountAndReturn()
        {
            string returned = device.InstallApp("YouTube", 400);
            string expected = "YouTube is installed successfully. Run application?";
            Assert.AreEqual(expected, returned);
            Assert.AreEqual(600, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
        }

        [Test]
        public void Test_InstallingAppWithBiggerSizeThrows()
        {
            TestDelegate testDelegate = () => device.InstallApp("Minecraft",1200);
            Assert.Throws<InvalidOperationException>(testDelegate);
        }

        [Test]
        public void Test_FormattingDeletesPhostosAndApplications()
        {
            device.TakePhoto(100);
            device.InstallApp("Facebook",400);
            device.FormatDevice();

            Test_Constructor();
        }

        [Test]
        public void Test_GettingDeviceStatusReturns()
        {
            device.TakePhoto(100);
            device.InstallApp("Instagram", 300);
            device.InstallApp("YouTube", 400);

            string returned = device.GetDeviceStatus();

            StringBuilder expected = new StringBuilder();
            expected.AppendLine($"Memory Capacity: 1000 MB, Available Memory: 200 MB");
            expected.AppendLine($"Photos Count: 1");
            expected.AppendLine($"Applications Installed: Instagram, YouTube");

            Assert.AreEqual(expected.ToString().Trim(), returned );
        }
    }
}