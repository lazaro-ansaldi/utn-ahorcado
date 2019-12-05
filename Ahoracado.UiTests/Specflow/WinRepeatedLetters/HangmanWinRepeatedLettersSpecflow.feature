Feature: HangmanWinRepeatedLettersSpecflow

	In order to play the game
	As a player
	I want to guess a word and know if I won or not

@WordWinRepeatedLettersScenario
Scenario: Win the game with letters
	Given I have entered fees as the wordToGuess
	When I try the letter f
	When I try the letter e
	When I try the letter s
	Then I should be told that I win the game