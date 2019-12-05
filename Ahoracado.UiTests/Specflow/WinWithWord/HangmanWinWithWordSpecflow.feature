Feature: HangmanWinWithWordSpecflow

	In order to play the game
	As a player
	I want to guess a word and know if I won or not

@WordWinScenario
Scenario: Win the game with a word
	Given I have entered house as the wordToGuess
	When I try the letter h
	When I try the word house
	Then I should be told that I win the game with word