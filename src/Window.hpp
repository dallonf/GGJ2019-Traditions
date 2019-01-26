#pragma once
#include <SDL2/SDL.h>

class Window
{
	SDL_Window * _window;
	SDL_Renderer * _renderer;
public:
	Window (int w, int h);
	~Window();

	SDL_Window * get_window() {return _window;}
	SDL_Renderer * get_renderer() {return _renderer;}
};
