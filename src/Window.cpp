#include "Window.hpp"

Window::Window (int w, int h)
{
	SDL_CreateWindowAndRenderer (w, h, SDL_WINDOW_RESIZABLE, &_window, &_renderer);
}

Window::~Window()
{
	SDL_DestroyRenderer (_renderer);
	SDL_DestroyWindow (_window);
}
