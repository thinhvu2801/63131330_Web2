package jp.ivs.controller;

import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class WelcomeController {
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
	@RequestMapping("/contact")
	public String contact(ModelMap model) {
		model.addAttribute("msg", "Helo maven");
		return "viewContact";
	}
	@RequestMapping("/faq")
	public String faq(ModelMap model) {
		model.addAttribute("msg", "Helo maven");
		return "viewFaq";
	}
}