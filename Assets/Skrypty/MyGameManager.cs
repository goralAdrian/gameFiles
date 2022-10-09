using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;

public class MyGameManager : MonoBehaviour
{
	string path = "";
	public string[] splitArray;
	public GameObject[] bloki = new GameObject[3];
	
	public Caretaker c;
	float timerOfTime = 0;
	int timer = 0;
	int timer2 = 0;
	public int budget = 0, budget2 = 0;
	public int people = 0, people2 = 0;
	int randomNumber = 0;
	Customers customeres;
	private List<Vector2> listOfVector = new List<Vector2>();
	public List<GameObject> listOfObjects = new List<GameObject>();
	
	private List<Vector2> listOfVector2 = new List<Vector2>();
	public List<GameObject> listOfObjects2 = new List<GameObject>();

	public static Vector2 zmiennastatyczna;
	

	public int[][] tab;

	public Vector2 actual;
	public GameObject myObject;

	public static GameObject gameObjectWybrany;

	public GameObject[] mojetypy;

	public string[,] tableOfVariables = new string[64, 2];
	bool breakingCircle = false;

	public string textToShow = "1";
	public Originator o;

	//Abstraction ab = new RefinedAbstraction();
	int timer2b = 0;

	public spawnManagerValuesClass spawnManagerValues;
	
	public void restartPlace()
	{
		SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
	}
	
	
	void Start()
	{
		
		if(spawnManagerValues == null)
		{
			spawnManagerValues = new spawnManagerValuesClass();
		}
		
		timerOfTime = 0;
		
		timer = 0;
		timer2 = 0;
		budget = 0;
		people = 0;
		randomNumber = 1;
		int i = 0;
		do
		{
			tableOfVariables[i, 0] = "";
			tableOfVariables[i, 1] = "";
			i++;
		} while (i < 64);

		int xxx = 0, x2 = 0;


		o = new Originator();
		o.State = listOfVector;
		o.State2 = listOfObjects;
		
		c = new Caretaker();
		c.Memento = o.CreateMemento();
		
		listOfVector2 = listOfVector;
		listOfObjects2 = listOfObjects;
		
		if(!(spawnManagerValues.isLoading==null))
		{
			spawnManagerValues.isLoading = false;
		}
		if(spawnManagerValues.isLoading)
		{	
			spawnManagerValues.isLoading = false;
			/*
			Debug.Log(spawnManagerValues.isLoading + " <--- loded 2");
			//ogarnac tworzenie plikow z listy
			if(!(spawnManagerValues.state==null))
			{
				listOfVector = spawnManagerValues.state;
				listOfObjects = spawnManagerValues.state2;
				
				
				int counter = 0;
				if(listOfObjects.Count>0)
				{
					do
					{
						Debug.Log("LOADING " + counter);
						if(listOfObjects[counter].name=="1")
						{
							myObject = Instantiate(bloki[0]);
							myObject.name="1";
						}
						if(listOfObjects[counter].name=="2")
						{
							myObject = Instantiate(bloki[1]);
							myObject.name="2";
						}
						if(listOfObjects[counter].name=="3")
						{
							myObject = Instantiate(bloki[2]);
							myObject.name="3";
						}
						
						
						myObject.transform.position = new Vector3(listOfVector[counter].x, listOfVector[counter].y, 0);
						
						counter++;
					}while(counter < listOfObjects.Count);
				}
				
				//
				
				
				timer2 = spawnManagerValues.state3;
				people = spawnManagerValues.state4;
				budget = spawnManagerValues.state5;
			}
			spawnManagerValues.isLoading = false;
			*/
			
		}
		Debug.Log(spawnManagerValues.isLoading + " <--- loded");
	}

	void uruchom()
	{
		SceneManager.LoadScene("Scene");
	}
	void Update()
{
	Abstraction ab = new RefinedAbstraction();
	if (Input.GetKey(KeyCode.F1))
	{
		Debug.Log("info");
	}

	/*
	opcje zapisu i  wczytania
	*/
	/*
	if (Input.GetKey(KeyCode.Q))
	{
		o.State = listOfVector;
		o.State2 = listOfObjects;
		o.State3 = budget;
		o.State4 = people;
		
		c = new Caretaker();
		c.Memento = o.CreateMemento();

		Debug.Log("1a");
	}

	if (Input.GetKey(KeyCode.W))
	{
		listOfVector = o.State;
		listOfObjects = o.State2;
		budget = o.State3;
		people = o.State4;
		Debug.Log("2a");
	}
	*/
	if (Input.GetKey(KeyCode.E))
	{
		Singleton s3 = Singleton.GetInstance();
	}


	timerOfTime += Time.deltaTime;

	listOfVector.Clear();
	foreach (GameObject a in listOfObjects)
	{
		listOfVector.Add(new Vector2(a.GetComponent<Transform>().position.x, a.GetComponent<Transform>().position.y));
	}
	if(budget>10000000)
	{
		String ResultValue = Convert.ToString(timer2);
		File.WriteAllText("BestScore.txt", "Twoj wynik to: " + ResultValue + " cykli");

		SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
	}
	if(timer==1000 || timer>1000)
	{

		GameObject.Find("PeopleCounter").GetComponent<UnityEngine.UI.Text>().text = "Mieszkańców: " + people;
		GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
		GameObject.Find("Premia").GetComponent<UnityEngine.UI.Text>().text = "";
		timer=0;
	}
	
	if(timer==24000 || timer>24000)
	{
		if(randomNumber>8 || randomNumber<1)
		{
			randomNumber = 4;
			Singleton s1 = Singleton.GetInstance();
			showInfo();
		}
		if(randomNumber==1)
		{
			Debug.Log("1");
			GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Z podowu zalania kilku budynkow, miasto musi oplacic remonty tychze budynkow.";
			budget = budget - 25000;
			GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
			randomNumber = 3;
			Singleton s2 = Singleton.GetInstance();
		}
		if(randomNumber==2)
		{
			Debug.Log("2");
			GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Kapela metalowa przyjechala do miasta podczas trasy koncertowej, przez co miasto zyskuje pewna sumke pieniedzy zwiazana z rzesza fanow.";
			budget = budget + 12500;
			GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
			randomNumber = 4;
		}
		if(randomNumber==3)
		{
			Debug.Log("3");
			GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Po prostu zwykla premia, co tu duzo mowic, oto Twoje Cr. 10 000";
			budget = budget + 10000;
			GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
			randomNumber = 5;
		}
		if(randomNumber==4)
		{
			Debug.Log("4");
			GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Po prostu zwykla premia, co tu duzo mowic, oto Twoje Cr. 15 000";
			budget = budget + 15000;
			GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
			randomNumber = 6;
		}
		if(randomNumber==5)
		{
			Debug.Log("5");
			GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Po prostu zwykla premia, co tu duzo mowic, oto Twoje Cr. 20 000";
			budget = budget + 20000;
			GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
			randomNumber = 7;
			Singleton s3 = Singleton.GetInstance();
		}
		if(randomNumber==6)
		{
			Debug.Log("6");
			GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Po prostu zwykla premia, co tu duzo mowic, oto Twoje Cr. 25 000";
			budget = budget + 25000;
			GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
			randomNumber = 8;
		}
		if(randomNumber==7)
		{
			Debug.Log("7");
			GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Po prostu zwykla premia, co tu duzo mowic, oto Twoje Cr. 50 000";
			budget = budget + 50000;
			GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
			randomNumber = 2;
		}
		if(randomNumber==8)
		{
			Debug.Log("8");
			GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Z powodu konfliktu interesów z Czechami, musisz zapłacić Cr. 1 000 000 kary.";
			budget = budget - 1000000;
			GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
			randomNumber = 1;
		}
	}
	
	if(timer2 % 5500 ==0)
	{
		budget = budget - 25000;
		GameObject.Find("Premia").GetComponent<UnityEngine.UI.Text>().text = "Z powodu na kleske, Twoj ratusz musial zaplacic mieszkancom 25 000 Cr. w celu rekompensat";
		ab.Implementor = new ConcreteImplementorA();
		ab.Operation();
	}
	if(timer2 % 11000 ==0)
	{
		budget = budget - 50000;
		GameObject.Find("Premia").GetComponent<UnityEngine.UI.Text>().text = "Z powodu na kleske, Twoj ratusz musial zaplacic mieszkancom 50 000 Cr. w celu rekompensat";
		ab.Implementor = new ConcreteImplementorB();
		ab.Operation();
	}
	if (Input.GetKey(KeyCode.Q))
	{
		listOfVector2 = listOfVector;
		listOfObjects2 = listOfObjects;
		timer2b = timer2;
		people2 = people;
		budget2 = budget;

		spawnManagerValues.state = listOfVector;
		spawnManagerValues.state2 = listOfObjects;
		spawnManagerValues.state3 = timer2;
		spawnManagerValues.state4 = people;
		spawnManagerValues.state5 = budget;
		spawnManagerValues.isLoading = false;
		
		
		StringBuilder stringBud = new StringBuilder();
		StringBuilder stringBud2 = new StringBuilder();
		StringBuilder stringBud3 = new StringBuilder();
		StringBuilder stringBud4 = new StringBuilder();
        path = "file.txt";//EditorUtility.SaveFilePanel("Zapisz schemat jako", "", "savingFile.txt", "txt");

        if (path.Length != 0)
        {
            for (int i = 0; i < GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Count; i++)
            {
               if(GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].transform.position.x.Equals("100"))
                stringBud.Append(GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].name);
                stringBud.Append(GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].name);
                stringBud.Append(";");
                stringBud.Append(GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].transform.position.x);
                stringBud.Append(";");
                stringBud.Append(GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].transform.position.y);
                stringBud.Append(";");

                stringBud.Append("¡");
                stringBud.Append("\r\n");
            }
            File.WriteAllText(path, stringBud.ToString());
        }
		path = "file2.txt";//EditorUtility.SaveFilePanel("Zapisz schemat jako", "", "savingFile.txt", "txt");

        if (path.Length != 0)
        {
			stringBud2.Append(timer2);
            File.WriteAllText(path, stringBud2.ToString());
        }
		
		path = "file3.txt";//EditorUtility.SaveFilePanel("Zapisz schemat jako", "", "savingFile.txt", "txt");

        if (path.Length != 0)
        {
			stringBud3.Append(people);
            File.WriteAllText(path, stringBud3.ToString());
        }
		path = "file4.txt";//EditorUtility.SaveFilePanel("Zapisz schemat jako", "", "savingFile.txt", "txt");

        if (path.Length != 0)
        {
			stringBud4.Append(budget);
            File.WriteAllText(path, stringBud4.ToString());
        }
	}

	if (Input.GetKey(KeyCode.W))
	{
		/*
		spawnManagerValues.isLoading = true;
		SceneManager.LoadScene("Scene");
		*/
		
		
		
		Debug.Log("Loading");
        int i = 0;
        path = "C:/Users/ja/Documents/Moj Projekt Kopia/file.txt";// EditorUtility.OpenFilePanel("Otwórz plik", "Wybierz plik", "txt");
        string stringToParse = "";
        if (!path.ToString().Equals(null))
        {
			Debug.Log("Load1");
            stringToParse = File.ReadAllText(@path, Encoding.UTF8);
            char[] b = { '¡' };                         //¡ oddziela linijki
            splitArray = stringToParse.Split(b);
            string[] line;
            Vector3 vectorOfElem;                       //vector odpowiedzialny za umiejscowienie elementow na planszy podczas ladowania



			Debug.Log("Load2");
            for (i = 0; i < GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Count; i++)
            {
                GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].gameObject.SetActive(false);
                GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects[i].transform.position = new Vector2(100, 100);
            }
			Debug.Log("Load3");
            i = 0;
            int j = 0;
            int x = 1, y = 1;
            bool foundStart = false, foundStop = false;
            if (stringToParse.Length > 0)
            {
				Debug.Log("Load4");
                if (splitArray.Length > 1)
                {
					Debug.Log("Load5");
                    i = 0;
					do
					{
						line = splitArray[i].Split(';');
						if (line[1] != "100" && line[2] != "100")
						{
							
							if(line[0].Contains("1"))
							{
								Debug.Log("Load6." + i);
								myObject = Instantiate(bloki[0]);
								myObject.name="1";
								
								GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Add(myObject);
								vectorOfElem = new Vector3(int.Parse(line[1]), int.Parse(line[2]), 0);
								myObject.name = "1";
								Debug.Log(myObject.name);
							}
							if(line[0].Contains("2"))
							{
								Debug.Log("Load6." + i);
								myObject = Instantiate(bloki[1]);
								myObject.name="2";
								
								GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Add(myObject);
								vectorOfElem = new Vector3(int.Parse(line[1]), int.Parse(line[2]), 0);
								myObject.name = "2";
								Debug.Log(myObject.name);
							}
							if(line[0].Contains("3"))
							{
								Debug.Log("Load6." + i);
								myObject = Instantiate(bloki[2]);
								myObject.name="3";
								
								GameObject.Find("Main Camera").GetComponent<MyGameManager>().listOfObjects.Add(myObject);
								vectorOfElem = new Vector3(int.Parse(line[1]), int.Parse(line[2]), 0);
								myObject.name = "3";
								Debug.Log(myObject.name);
							}
						}

						i++;
					} while (i < splitArray.Length - 1);

                }
            }
        }
		else
		{
			Debug.Log("brak pliku");
		}
		
		path = "C:/Users/ja/Documents/Moj Projekt Kopia/file2.txt";// EditorUtility.OpenFilePanel("Otwórz plik", "Wybierz plik", "txt");
		if (!path.ToString().Equals(null))
		{
			stringToParse = File.ReadAllText(@path, Encoding.UTF8);
			if (stringToParse.Length > 0)
			{
				Int32.TryParse(stringToParse, out timer2);
			}
		}
		
		path = "C:/Users/ja/Documents/Moj Projekt Kopia/file3.txt";// EditorUtility.OpenFilePanel("Otwórz plik", "Wybierz plik", "txt");
		if (!path.ToString().Equals(null))
		{
			stringToParse = File.ReadAllText(@path, Encoding.UTF8);
			if (stringToParse.Length > 0)
			{
				Int32.TryParse(stringToParse, out people);
			}
		}
		
		path = "C:/Users/ja/Documents/Moj Projekt Kopia/file4.txt";// EditorUtility.OpenFilePanel("Otwórz plik", "Wybierz plik", "txt");
		if (!path.ToString().Equals(null))
		{
			stringToParse = File.ReadAllText(@path, Encoding.UTF8);
			if (stringToParse.Length > 0)
			{
				Int32.TryParse(stringToParse, out budget);
			}
		}
		
	}

	timer2++;
	timer++;

	GameObject.Find("PeopleCounter").GetComponent<UnityEngine.UI.Text>().text = "Mieszkańców: " + people;
	GameObject.Find("BudgetCounter").GetComponent<UnityEngine.UI.Text>().text = "Budżet: " + budget;
	GameObject.Find("Premia").GetComponent<UnityEngine.UI.Text>().text = "";
}

	public void showInfo()
	{
		Singleton singleton = Singleton.GetInstance();
	}

	/*
	singleton
	*/

	public sealed class Singleton
		{
		private Singleton() { }
		private static Singleton _instance;
		public static Singleton GetInstance()
		{
			if (_instance == null)
			{
				_instance = new Singleton();
				
			}
			Debug.Log("habababa dziala");
			return _instance;
		}
		public static void showInfoSingleton()
		{
			
			Debug.Log("przyznano premię");
			Debug.Log("habababa dziala");
		}
	}



	public class CustomersBase
	{
		private DataObject dataObject;
		public DataObject Data
		{
			set { dataObject = value; }
			get { return dataObject; }
		}
		public virtual void Next()
		{
			dataObject.NextRecord();
		}
		public virtual void Prior()
		{
			dataObject.PriorRecord();
		}
		public virtual void Add(string customer)
		{
			dataObject.AddRecord(customer);
		}
		public virtual void Delete(string customer)
		{
			dataObject.DeleteRecord(customer);
		}
		public virtual void Show()
		{
			dataObject.ShowRecord();
		}
		public virtual void ShowAll()
		{
			dataObject.ShowAllRecords();
		}
	}

	public class Customers : CustomersBase
	{
		public override void ShowAll()
		{
			Console.WriteLine();
			Console.WriteLine("------------------------");
			base.ShowAll();
			Console.WriteLine("------------------------");
		}
	}
	public abstract class DataObject
	{
		public abstract void NextRecord();
		public abstract void PriorRecord();
		public abstract void AddRecord(string name);
		public abstract void DeleteRecord(string name);
		public abstract string GetCurrentRecord();
		public abstract void ShowRecord();
		public abstract void ShowAllRecords();
	}
	public class CustomersData : DataObject
	{
		private readonly List<string> customers = new List<string>();
		private int current = 0;
		private string city;
		public CustomersData(string city)
		{
			this.city = city;
			// Loaded from a database 
			customers.Add("Jim Jones");
			customers.Add("Samual Jackson");
			customers.Add("Allen Good");
			customers.Add("Ann Stills");
			customers.Add("Lisa Giolani");
		}
		public override void NextRecord()
		{
			if (current <= customers.Count - 1)
			{
				current++;
			}
		}
		public override void PriorRecord()
		{
			if (current > 0)
			{
				current--;
			}
		}
		public override void AddRecord(string customer)
		{
			customers.Add(customer);
		}
		public override void DeleteRecord(string customer)
		{
			customers.Remove(customer);
		}
		public override string GetCurrentRecord()
		{
			return customers[current];
		}
		public override void ShowRecord()
		{
			Console.WriteLine(customers[current]);
		}
		public override void ShowAllRecords()
		{
			Console.WriteLine("Customer City: " + city);
			foreach (string customer in customers)
			{
				Console.WriteLine(" " + customer);
			}
		}
	}
	/*
	bridge
	*/
	
	public class Abstraction
	{
		protected Implementor implementor;
		public Implementor Implementor
		{
			set { implementor = value; }
		}
		public virtual void Operation()
		{
			implementor.Operation();
		}
	}
	
	public abstract class Implementor
	{
		public abstract void Operation();
	}

	public class RefinedAbstraction : Abstraction
	{
		public override void Operation()
		{
			implementor.Operation();
		}
	}

	public class ConcreteImplementorA : Implementor
	{
		public override void Operation()
		{
			
			GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Z powodu na kleske, Twoj ratusz musial zaplacic mieszkancom 25 000 Cr. w celu rekompensat";
		}
	}

	public class ConcreteImplementorB : Implementor
	{
		public override void Operation()
		{
			GameObject.Find("TextInfoPanel").GetComponent<UnityEngine.UI.Text>().text = "Z powodu kleski, Twoj ratusz musial zaplacic mieszkancom 50 000 Cr. w celu rekompensat";
		}
	}
}


	/*
	memento, odpowiedzialne za zapamiętywania danych
	*/

	public class Originator
	{
		List<Vector2> state;
		List<GameObject> state2;
		int state3;
		int state4;
		
		public List<Vector2> State
		{
			get { Debug.Log("2--a");return state; }
			set
			{
				state = value;
				Console.WriteLine("State = " + state);
			}
		}
		
		public List<GameObject> State2
		{
			get { Debug.Log("2--b");return state2; }
			set
			{
				state2 = value;
				Console.WriteLine("State = " + state2);
			}
		}
		public int State3
		{
			get { Debug.Log("2--b");return state3; }
			set
			{
				state3 = value;
				Console.WriteLine("State = " + state3);
			}
		}
		public int State4
		{
			get { Debug.Log("2--b");return state4; }
			set
			{
				state4 = value;
				Console.WriteLine("State = " + state4);
			}
		}

		public Memento CreateMemento()
		{
			Debug.Log("1b");
			return (new Memento(state, state2, state3, state4));
		}

		public void SetMemento(Memento memento)
		{
			Console.WriteLine("Restoring state...");
			State = memento.State;
		}
	}

	public class Memento
	{
		List<Vector2> state;
		List<GameObject> state2;
		int state3;
		int state4;

		public Memento(List<Vector2> state, List<GameObject> state2, int state3, int state4)
		{
			Debug.Log("1c");
			this.state = state;
			this.state2 = state2;
			this.state3 = state3;
			this.state4 = state4;
			
			Debug.Log(state);
			Debug.Log(state2);
			Debug.Log("--//--");
		}
		public List<Vector2> State
		{
			
			get { Debug.Log("2c1"); return state; }
		}
		public List<GameObject> State2
		{
			
			get { Debug.Log("2c2"); return state2; }
		}
	}

	public class Caretaker
	{
		Memento memento;
		public Memento Memento
		{
			set { Debug.Log("2bb"); memento = value; }
			get { Debug.Log("2b");return memento; }
		}
		
	}
	
	[CreateAssetMenu(fileName = "Data", menuName = "Examples/ExamoleScriptableObject")]
	public class spawnManagerValuesClass : ScriptableObject
	{
		public List<Vector2> state;
		public List<GameObject> state2;
		public int state3;
		public int state4;
		public int state5;
		public bool isLoading;
	}
	/*
		bridge
	*/
	
	/*
	public class SalesProspect
	{
		List<Vector2> listOfVector2;
		List<GameObject> listOfObjects2;
		public List<Vector2> listOfVector
		{
			get { Console.WriteLine("loaded Vector");return listOfVector2; }
			set
			{
				Console.WriteLine("saved Vector");
				listOfVector2 = value;
			}
		}

		public List<GameObject> listOfObjects
		{
			get { Console.WriteLine("loaded List of objects");return listOfObjects2; }
			set
			{
				Console.WriteLine("saved List of objects");
				listOfObjects2 = value;
			}
		}

		public Memento SaveMemento()
		{
			//Console.WriteLine("\nSaving state --\n");
			return new Memento(listOfVector, listOfObjects);
		}

		public void RestoreMemento(Memento memento)
		{
			Console.WriteLine("\nRestoring state --\n");
			listOfVector = memento.listOfVector;
			listOfObjects = memento.listOfObjects;
		}
	}

	public class Memento
	{
		List<Vector2> listOfVector2;
		List<GameObject> listOfObjects2;

		public Memento(List<Vector2> listOfVector, List<GameObject> listOfObjects)
		{
			this.listOfVector2 = listOfVector2;
			this.listOfObjects2 = listOfObjects2;
		}
		public List<Vector2> listOfVector
		{
			get { return listOfVector2; }
			set { listOfVector2 = value; }
		}
		public List<GameObject> listOfObjects
		{
			get { return listOfObjects2; }
			set { listOfObjects2 = value; }
		}
	}

	public class Mem_Pros
	{
		Memento memento;
		public Memento Memento
		{
			set { memento = value; }
			get { return memento; }
		}
	}
	
	*/




	/*
		Bridge
	*/
/*
public class CustomersBase
	{
	private DataObject dataObject;

	public DataObject Data
	{
		set { dataObject = value; }
		get { return dataObject; }
	}

	public virtual void Next()
	{
		dataObject.NextRecord();
	}

	public virtual void Prior()
	{
		dataObject.PriorRecord();
	}

	public virtual void Add(string customer)
	{
		dataObject.AddRecord(customer);
	}

	public virtual void Delete(string customer)
	{
		dataObject.DeleteRecord(customer);
	}

	public virtual void Show()
	{
		dataObject.ShowRecord();
	}

	public virtual void ShowAll()
	{
		dataObject.ShowAllRecords();
	}
}

public abstract class DataObject
{
	public abstract void NextRecord();
	public abstract void AddRecord(string name);
	public abstract void DeleteRecord(string name);
	public abstract string GetCurrentRecord();
	public abstract void ShowRecord();
	public abstract void ShowAllRecords();
}

public class CustomersData : DataObject
{
	private readonly List<Double> premia = new List<Double>();
	private int current = 0;

	public CustomersData(string city)
	{

		premia.Add(200.00);
		premia.Add(250.00);
		premia.Add(500.00);
		premia.Add(12500.00);
	}

	public override void NextRecord()
	{
		if (current <= customers.Count - 1)
		{
			current++;
		}
	}

	public override void AddRecord(string customer)
	{
		customers.Add(customer);
	}

	public override void DeleteRecord(string customer)
	{
		customers.Remove(customer);
	}

	public override string GetCurrentRecord()
	{
		return customers[current];
	}

	public override void ShowRecord()
	{
		Console.WriteLine(customers[current]);
	}

	public override void ShowAllRecords()
	{
		Console.WriteLine("Customer City: " + city);

		foreach (string customer in customers)
		{
			Console.WriteLine(" " + customer);
		}
	}
}
public class Customers : CustomersBase
{
	public override void ShowAll()
	{
		// Add separator lines

		Console.WriteLine();
		base.ShowAll();
	}
}

*/
