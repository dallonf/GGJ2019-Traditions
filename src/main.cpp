#include <SDL2/SDL.h>
#include <cassert>

#include "GameManager.hpp"

int main (int argc, char ** argv)
{
	assert (SDL_Init (SDL_INIT_EVERYTHING) == 0);

	GameManager game;

	while (game.run_loop()) SDL_Delay (1000/24);

	SDL_Quit();
	return EXIT_SUCCESS;
}
