package com.vmt.bookwarehousemanagement.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

import com.vmt.bookwarehousemanagement.entities.Sach;
import com.vmt.bookwarehousemanagement.services.SachService;

@Controller
@RequestMapping("/sach")
public class SachController {

    @Autowired
    private SachService sachService;

    // Trang danh sách sách
    @GetMapping("/list")
    public String getAllSach(Model model) {
        model.addAttribute("sachList", sachService.getAllSach());
        return "sach/sach-list";
    }

    // Trang thêm sách
    @GetMapping("/add")
    public String addSachForm(Model model) {
        model.addAttribute("sach", new Sach());
        return "sach/add-sach";
    }

    // Xử lý thêm sách
    @PostMapping("/add")
    public String addSachSubmit(@ModelAttribute Sach sach) {
        sachService.saveOrUpdateSach(sach);
        return "redirect:/sach/list";
    }

    // Trang sửa sách
    @GetMapping("/edit/{id}")
    public String editSachForm(@PathVariable Long id, Model model) {
        Sach sach = sachService.getSachById(id).orElse(null);
        model.addAttribute("sach", sach);
        return "sach/edit-sach";
    }

    // Xử lý sửa sách
    @PostMapping("/edit/{id}")
    public String editSachSubmit(@PathVariable Long id, @ModelAttribute Sach sach) {
        sach.setId(id); // Đảm bảo ID được set
        sachService.saveOrUpdateSach(sach);
        return "redirect:/sach/list";
    }

    // Xoá sách
    @GetMapping("/delete/{id}")
    public String deleteSach(@PathVariable Long id) {
        sachService.deleteSach(id);
        return "redirect:/sach/list";
    }
    // Trang chi tiết sách
    @GetMapping("/detail/{id}")
    public String getSachDetail(@PathVariable Long id, Model model) {
        Sach sach = sachService.getSachById(id).orElse(null);
        if (sach == null) {
            // Xử lý trường hợp sách không tồn tại
            return "redirect:/sach/list";
        }
        model.addAttribute("sach", sach);
        return "sach/sach-detail";
    }

}
