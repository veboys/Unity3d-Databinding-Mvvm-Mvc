using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Databinding.Model;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DatabindingTester : ObservableBehaviour
{


    public Text Output;


    private int _property1;
    public int Property1
    {
        get { return _property1; }
        set
        {
            if (_property1 == value)
                return;
            _property1 = value;
            NotifyProperty("Property1", value);
        }
    }



    private int _property2;
    public int Property2
    {
        get { return _property2; }
        set
        {
            if (_property2 == value)
                return;
            _property2 = value;
            Set(ref _property2, value);
        }
    }

    public int Property3 { get; set; }


    public string Log
    {
        set
        {
            var old = Output.text;
            Output.text = value + Environment.NewLine + old;
        }
    }


    private double average1;
    private double average2;
    private double average3;

    IEnumerator Start()
    {
        Output.text = "Starting Tests";

        yield return StartCoroutine(Update1());
        yield return StartCoroutine(Update2());
        yield return StartCoroutine(Update3());

        Log = "Ending Tests";
        Log = string.Format("Average {0} {1} {2}", average1, average2, average3);
    }

    IEnumerator Update1()
    {
        Log = "Testing Old Raise Method";

        var times = new List<double>();

        for (int i = 0; i < 500; i++)
        {
            var s = DateTime.UtcNow;
            Property1 = 0;

            for (int x = 0;x < 100;x++)
            {
                Property1 = x;
            }

            var e = DateTime.UtcNow;

            times.Add((e - s).TotalMilliseconds);
            //Log = s.ToString();

            yield return 1;
        }

        average1 = times.Sum()/times.Count;
        Log = "Average " + times.Sum() / times.Count;
        Log = "";
    }

    IEnumerator Update2()
    {
        Log = "Testing New Raise Method";

        var times = new List<double>();

        for (int i = 0;i < 500;i++)
        {
            var s = DateTime.UtcNow;
            Property2 = 0;

            for (int x = 0;x < 100;x++)
            {
                Property2 = x;
            }

            var e = DateTime.UtcNow;
            times.Add((e - s).TotalMilliseconds);
            //Log = s.ToString();

            yield return 1;
        }


        average2 = times.Sum() / times.Count;
        Log = "Average " + times.Sum() / times.Count;
        Log = "";
    }
    IEnumerator Update3()
    {
        Log = "Testing Without Raise Method";

        var times = new List<double>();

        for (int i = 0;i < 500;i++)
        {
            var s = DateTime.UtcNow;
            Property3 = 0;

            for (int x = 0;x < 100;x++)
            {
                Property3 = x;
            }

            var e = DateTime.UtcNow;
            times.Add((e - s).TotalMilliseconds);
            //Log = s.ToString();

            yield return 1;
        }


        average3 = times.Sum() / times.Count;
        Log = "Average " + times.Sum() / times.Count;
        Log = "";
    }
}
