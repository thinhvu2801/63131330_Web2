
package thomc.JPAdemoQLBH.controllers;
 
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

import thomc.JPAdemoQLBH.services.CustomerService;
import thomc.JPAdemoQLBH.models.Customer;
@Controller
@RequestMapping("/customer")
public class CustomerController {
	@Autowired CustomerService customerService;
	@GetMapping("/all")
	public String getAll(Model model) {
		List<Customer> dsKH = customerService.findAllCustomer();
		model.addAttribute("dsKhachHang", dsKH);
		return "danhsachKH";
	}
}
