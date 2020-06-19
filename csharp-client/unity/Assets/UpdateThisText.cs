using Senstate.CSharp_Client;
using Senstate.NetStandard;
using UnityEngine;
using UnityEngine.UI;

public class UpdateThisText : MonoBehaviour
{
    public Text MyText;

    private bool toggled;
    private int updateCount = 0;

    private Watcher m_stringWatcher;
    private Watcher m_updateCallCount;

    // Start is called before the first frame update
    void Start()
    {
        MyText.text = "Hello from Script - Press > space <";

        var webSocket = new NetStandardWebSocketImplementation();
        webSocket.ExceptionThrown += (sender, e) =>  // Optional if you want to catch Connection issues
        {
            throw e.Exception;
        };

        SenstateContext.SerializerInstance = new NetStandardJsonNetImplementation();
        SenstateContext.WebSocketInstance = webSocket; 
        SenstateContext.RegisterApp("Unity Example");


        m_stringWatcher = new Watcher(
   new WatcherMeta
   {
       Tag = "Label Text",
       Type = WatcherType.String, // or Number / Json
      }
);

        m_updateCallCount = new Watcher(
 new WatcherMeta
 {
     Tag = "Update All the Things",
     Type = WatcherType.Number, // or Number / Json
   }
);
    }

    // Update is called once per frame
    void Update()
    {
        updateCount++;

        if (updateCount > 1000000)
        {
            updateCount = 0;
        }

        if (Input.GetKeyDown("space"))
        {
            toggle();
        }

        if (Input.GetKeyDown("u"))
        {
            m_updateCallCount?.SendData(updateCount);
        }
    }

    private void toggle ()
    {
        if (toggled)
        {
            MyText.text = "de-spaced";
        } else
        {
            MyText.text = "spaced";
        }

        m_stringWatcher.SendData(MyText.text);
        toggled = !toggled;
    }
}
