package thiGK.ntu63131330.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class HomeController {
	@RequestMapping("/welcome")
	public String welcome(ModelMap model) {
		model.addAttribute("msg", "Helo maven");
		return "viewWelcome";
	}
	@RequestMapping("/index")
	public String index(ModelMap model) {
		model.addAttribute("msg", "Helo maven");
		return "viewIndex";
	}
	@RequestMapping("/about")
	public String about(ModelMap model) {
		model.addAttribute("msg", "Helo maven");
		return "viewAbout";
	}
}