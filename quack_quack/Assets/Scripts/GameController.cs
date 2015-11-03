using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private CSVReader reader;
	private int level;
	private string wordBank;
	private string wordChain;
	private char delimiter;
	private int wordsToComplete;
	public TextAsset wordBankCSV;
	public TextAsset wordChainCSV;
	// Use this for initialization
	void Start () {
		reader = GetComponent<CSVReader>();
		level = 0;
		wordBank = reader.getLine(wordBankCSV, level);
		wordChain = reader.getLine(wordChainCSV, level);
		delimiter = reader.getDelimiter();
		// get list of string (filled words) for word chain
		// get list of string (incomplete words) for word chain
		// get list of char's for wordBank
		// instantiate platforms and bridges
		// instantiate incomplete words on map
		// instantiate phonemes in word bank
		wordsToComplete = 3;
		makeStage (); //TODO!
	}
	
	// Update is called once per frame
	void Update () {
		if (wordsToComplete <= 0) {
			// TODO: congratz, fade out, load next level
		}
	}
	void wordCompleted() {
		wordsToComplete--;
	}
	void makeStage() {
		// Instantiate(<some GameObject> , position(x,y,z), rotation (0,0,0));
	}
}
