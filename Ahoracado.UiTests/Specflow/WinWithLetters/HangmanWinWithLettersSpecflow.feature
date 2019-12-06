Feature: HangmanWinWithLettersSpecflow
	In order to play the game
	As a player
	I want to guess a word and know if I won or not

@WinWithLettersScenario
Scenario: Win the game with letters
	Given I have entered Test as the wordToGuess
	When I enter t as the first typedLetter
	When I enter e as the second typedLetter
	When I enter s as the third typedLetter
	When I enter t as the fourth typedLetter
	Then I should be told that I win