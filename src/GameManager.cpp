#include "GameManager.hpp"

GameManager::GameManager()
	: _window (800, 600)
{
}

bool GameManager::run_loop()
{
	while (SDL_PollEvent (&_event))
	{
		switch (_event.type)
		{
		case SDL_QUIT:
			return false;
		}
	}
		
	// Rendering
	SDL_SetRenderDrawColor (_window.get_renderer(), 255, 127, 0, 255);
	SDL_RenderClear (_window.get_renderer());
		//draw calls
	SDL_RenderPresent (_window.get_renderer());
	return true;
}
