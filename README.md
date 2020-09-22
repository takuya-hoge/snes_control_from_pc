# snes_control_from_pc
SNES control from pc.  

amazonで安く売っているarduino nano を使用し、PCから手軽にスーパーファミコン操作することを目標に作っています。  

circuit_snes       : コントローラー乗っ取り用回路図  
ClassLibraryForPC  : Windows用テストプログラム(visual studio)  
sketch_snes        : arduino nano用のテストプログラム  
  
  
## テストプログラムの動作  

### テストプログラム1 の動作の様子  
単純なボタン操作ON／OFFを送信している
https://youtu.be/H7-xR-DRq8Y  
  
### テストプログラム2 の動作の様子  
単純なボタン操作だけでは必殺技が出せないため、hadokenコマンドを追加  
https://youtu.be/H0PTS4aQsgk  
https://youtu.be/6ZqasQNoWTM   

## 回路図  

![回路図](circuit_snes/circuit_snes.png)  
  
  
## 実装例  
雑に結線していますが、一番楽で確実な方法だと思われます。  
細い線ですが3本の矢の理論で沢山配線すると丈夫になり、簡単にはショートしません。  
黒い部分をやすりで削ると半田がのります。  
![回路図](circuit_snes/example.jpg)  
  
  
