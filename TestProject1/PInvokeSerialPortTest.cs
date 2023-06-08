using System.Text;
using Tyrael.Driver.SerialPort;

namespace TestProject1
{
    /// <summary>
    /// Test class. 
    /// Attention: Run it just in test debug.
    /// </summary>
    [TestClass]
    public class PInvokeSerialPortTest
    {
        dynamic _sender;
        dynamic _reciever;
        StringBuilder _stringBuilder;

        public void OpenWriteDoWaitClose(Action action = null)
        {
            const string testSting = "test";
            _stringBuilder = new StringBuilder();
            _sender.Open();
            _reciever.Open();

            action?.Invoke();

            _sender.Write(testSting);
            Thread.Sleep(100);
            Assert.AreEqual(testSting, _stringBuilder.ToString());

            Thread.Sleep(100);
            _sender.Close();
            _reciever.Close();
        }

        [TestMethod]
        public void OverallTest1()
        {
            _sender = new SerialPort("com3");
            _reciever = new SerialPort("com4");
            OpenWriteDoWaitClose(() =>
            {
                ((SerialPort)_reciever).DataReceived += x
                => _stringBuilder.Append((char)x);
            });
        }

        [TestMethod]
        public void OverallTest2()
        {
            _sender = new System.IO.Ports.SerialPort("com3")
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = System.IO.Ports.StopBits.Two,
                Parity = System.IO.Ports.Parity.None
            };
            SerialPort sp = _reciever = new SerialPort("com4")
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.Two,
                Parity = Parity.None,
            };
            sp.DataReceived += x => _stringBuilder.Append((char)x);

            OpenWriteDoWaitClose();
        }

        [TestMethod]
        public void OverallTest3()
        {
            _sender = new SerialPort("com3")
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.Two,
                Parity = Parity.None,
            };
            System.IO.Ports.SerialPort sp = _reciever = new System.IO.Ports.SerialPort("com4")
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = System.IO.Ports.StopBits.Two,
                Parity = System.IO.Ports.Parity.None
            };
            sp.DataReceived += (x, y) => _stringBuilder.Append(_reciever.ReadExisting());
            OpenWriteDoWaitClose();
        }

        [TestMethod]
        public void OverallTest4() // this is not really a PInvokeSerialTest :D
        {
            _sender = new System.IO.Ports.SerialPort("com3");
            System.IO.Ports.SerialPort sp = _reciever = new System.IO.Ports.SerialPort("com4");
            sp.DataReceived += (x, y) => _stringBuilder.Append(_reciever.ReadExisting());
            OpenWriteDoWaitClose();
        }
    }
}
