#pragma once
#include <SDL2/SDL.h>
#include "Window.hpp"

class GameManager
{
	Window _window;
	SDL_Event _event;
public:
	GameManager();

	bool run_loop();
};
