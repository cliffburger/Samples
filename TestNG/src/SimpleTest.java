import org.testng.annotations.*;
import org.testng.Reporter;

@Test
public class SimpleTest {

    @Test
    public void OutputDemo() {
        Reporter.log("Hello!",true );
    }
}
