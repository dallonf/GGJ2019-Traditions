#include <SDL2/SDL.h>
#include <cassert>

int main (int argc, char ** argv)
{
	assert (SDL_Init (SDL_INIT_EVERYTHING) == 0);
	return EXIT_SUCCESS;
}
