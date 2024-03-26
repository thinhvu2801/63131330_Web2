package thiGK.ntu63131330.services;

import org.springframework.stereotype.Service;
import thiGK.ntu63131330.models.SinhVien;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageImpl;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.PageRequest;
import java.util.List;
import java.util.ArrayList;
import java.util.Collections;

@Service
public class SinhVienServiceImpl implements SinhvienService {
    static List<SinhVien> dsSinhVien = new ArrayList<SinhVien>();
    static {
        dsSinhVien.add(new SinhVien("001", "Vũ Minh Thịnh"));
        dsSinhVien.add(new SinhVien("002", "Nguyễn Thị Hương"));
        dsSinhVien.add(new SinhVien("003", "Trần Văn Nam"));
        dsSinhVien.add(new SinhVien("004", "Lê Thị Lan"));
        dsSinhVien.add(new SinhVien("005", "Phạm Minh Tâm"));
        dsSinhVien.add(new SinhVien("006", "Hoàng Văn Đức"));
        dsSinhVien.add(new SinhVien("007", "Mai Thị Trang"));
        dsSinhVien.add(new SinhVien("008", "Đặng Văn Hoàn"));
        dsSinhVien.add(new SinhVien("009", "Bùi Thị Thu"));
        dsSinhVien.add(new SinhVien("010", "Lý Văn Thành"));
    }

    @Override
    public Page<SinhVien> findPaginated(Pageable pageable) {
        int pageSize = pageable.getPageSize();
        int currentPage = pageable.getPageNumber();
        int startItem = currentPage * pageSize;
        List<SinhVien> list;

        if (dsSinhVien.size() < startItem) {
            list = Collections.emptyList();
        } else {
            int toIndex = Math.min(startItem + pageSize, dsSinhVien.size());
            list = dsSinhVien.subList(startItem, toIndex);
        }
        Page<SinhVien> sinhvienPage = new PageImpl<SinhVien>(list, PageRequest.of(currentPage, pageSize),
                dsSinhVien.size());
        return sinhvienPage;
    }

    @Override
    public SinhVien findByMSSV(String mssv) {
        for (SinhVien sv : dsSinhVien) {
            if (sv.getMaSoSV().equals(mssv)) {
                return sv;
            }
        }
        return null;
    }

    @Override
    public void addSinhVien(SinhVien sinhVien) {
        dsSinhVien.add(sinhVien);
    }
}
