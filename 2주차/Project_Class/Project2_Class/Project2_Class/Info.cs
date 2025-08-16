// 클래스 : 변수와 변수를 사용하는 함수로 묶여진 데이터다.

// 클래스 문법 
// ㄴ 멤버 변수, 멤버 함수(메소드)로 구성 - 변수와 함수 선언 필요
// ㄴ 멤버 변수를 선언할 때 -> (접근 지정자) + (변수 타입) + (변수 이름)

// 접근 지정자? : 어떻게 접근 ㄱㄴ?
// ㄴ public : 공유 가능
// ㄴ private : 외부 사용 금지
// ㄴ protected : 외부 사용을 보호 / 자식은 허용

// 문법이 어렵다 : 접근 지정자 public으로만 써도 가능은 함
// ㄴ 권장사항으론 public을 사용하지 않기 -> 스파게티 코드 위험

//  생성자, 변수, 데이터를 저장하는 비어있는 공간.
// ㄴ 클래스의 이름과 똑같은 이름으로 함수를 만들어준다.

// 정보를 추상적으로 표현한 데이터 -> class 이름, (변수, 함수) 스코프 연산자 { }

using System.Xml.Linq;

class Info
{
    // 멤버 변수
    public string name;
    private string _name;

    // 멤버 함수
    public void SetName(string name)
    {
        name = _name;
    }
}

public class money
{
    Money = money;
}