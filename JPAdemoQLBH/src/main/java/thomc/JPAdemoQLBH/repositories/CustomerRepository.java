
package thomc.JPAdemoQLBH.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import thomc.JPAdemoQLBH.models.Customer;

@Repository
public interface CustomerRepository extends JpaRepository<Customer, Integer>  {
 
}
