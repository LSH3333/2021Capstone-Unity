// 사용자가 <input> 에서 text file을 선택해야함. 
// 경로에 따라 자동으로 불러오는 방법은 아직 찾는중.
var content = 1;

// id='file'에 파일입력시 
document.getElementById('txt_file').onchange = function(){

    var file = this.files[0];
    
    var reader = new FileReader();
    reader.onload = function(progressEvent){
      // 전체 파일 
      //console.log(this.result);      
  
      // 라인별 
      // line by line으로 split 
      var lines = this.result.split('\n');
      for(var line = 0; line < lines.length; line++){
        // console.log(lines[line]);
        // content 번호 순으로 텍스트파일의 각 라인 가져와서 HTML 수정 
        document.getElementById(content).innerHTML = lines[line];        
        content++;
      }
    };
    reader.readAsText(file);
  };