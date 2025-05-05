using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearachAppSample.Core
{
    public class AutoCompleteProvider
    {
        private readonly Dictionary<string, List<string>> _suggestions = new();
        private readonly int _maxSuggestions;

        public AutoCompleteProvider(int maxSuggestions = 10)
        {
            _maxSuggestions = maxSuggestions;
        }

        public void AddSuggestions(string category, IEnumerable<string> values)
        {
            if (!_suggestions.ContainsKey(category))
            {
                _suggestions[category] = new List<string>();
            }

            foreach (var value in values)
            {
                if (!string.IsNullOrWhiteSpace(value) &&
                    !_suggestions[category].Contains(value))
                {
                    _suggestions[category].Add(value);
                }
            }

            // 最大数に制限
            if (_suggestions[category].Count > _maxSuggestions)
            {
                _suggestions[category] = _suggestions[category]
                    .Take(_maxSuggestions).ToList();
            }
        }

        public List<string> GetSuggestions(string category, string prefix)
        {
            if (!_suggestions.ContainsKey(category))
                return new List<string>();

            return _suggestions[category]
                .Where(s => s.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                .OrderBy(s => s)
                .Take(_maxSuggestions)
                .ToList();
        }

        public void ApplyToTextBox(TextBox textBox, string category)
        {
            if (_suggestions.ContainsKey(category))
            {
                textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

                var source = new AutoCompleteStringCollection();
                source.AddRange(_suggestions[category].ToArray());
                textBox.AutoCompleteCustomSource = source;
            }
        }
    }

    public class SuggestionBox
    {
        private readonly ListBox _suggestionList;
        private readonly TextBox _textBox;
        private bool _suppressSelectionChange;

        public SuggestionBox(TextBox textBox)
        {
            _textBox = textBox;

            _suggestionList = new ListBox
            {
                Visible = false,
                TabStop = false,
                IntegralHeight = true,
                BorderStyle = BorderStyle.FixedSingle,
                Font = _textBox.Font
            };

            _textBox.Parent.Controls.Add(_suggestionList);

            // イベントハンドラーの設定
            _textBox.TextChanged += TextBox_TextChanged;
            _textBox.LostFocus += (s, e) =>
            {
                if (!_suggestionList.Focused)
                    HideSuggestions();
            };
            _textBox.KeyDown += TextBox_KeyDown;

            _suggestionList.Click += SuggestionList_Click;
            _suggestionList.SelectedIndexChanged += SuggestionList_SelectedIndexChanged;
            _suggestionList.LostFocus += (s, e) =>
            {
                if (!_textBox.Focused)
                    HideSuggestions();
            };
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSuggestions();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_suggestionList.Visible) return;

            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (_suggestionList.Items.Count > 0)
                    {
                        _suggestionList.SelectedIndex =
                            (_suggestionList.SelectedIndex + 1) % _suggestionList.Items.Count;
                        e.Handled = true;
                    }
                    break;

                case Keys.Up:
                    if (_suggestionList.Items.Count > 0)
                    {
                        _suggestionList.SelectedIndex =
                            (_suggestionList.SelectedIndex - 1 + _suggestionList.Items.Count) % _suggestionList.Items.Count;
                        e.Handled = true;
                    }
                    break;

                case Keys.Enter:
                case Keys.Tab:
                    if (_suggestionList.Visible && _suggestionList.SelectedItem != null)
                    {
                        ApplySelectedSuggestion();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;

                case Keys.Escape:
                    HideSuggestions();
                    e.Handled = true;
                    break;
            }
        }

        private void SuggestionList_Click(object sender, EventArgs e)
        {
            ApplySelectedSuggestion();
        }

        private void SuggestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChange) return;

            if (_suggestionList.SelectedItem != null)
            {
                // 選択しても即適用しない（クリックやEnterキーで確定）
            }
        }

        private void ApplySelectedSuggestion()
        {
            if (_suggestionList.SelectedItem == null) return;

            string selectedText = _suggestionList.SelectedItem.ToString();
            _textBox.Text = selectedText;
            _textBox.SelectionStart = selectedText.Length;
            _textBox.SelectionLength = 0;

            HideSuggestions();
            _textBox.Focus();
        }

        public void UpdateSuggestions(List<string> suggestions = null)
        {
            if (string.IsNullOrEmpty(_textBox.Text))
            {
                HideSuggestions();
                return;
            }

            if (suggestions != null && suggestions.Count > 0)
            {
                _suppressSelectionChange = true;
                _suggestionList.DataSource = null;
                _suggestionList.Items.Clear();
                _suggestionList.DataSource = suggestions;
                _suppressSelectionChange = false;

                if (_suggestionList.Items.Count > 0)
                {
                    _suggestionList.SelectedIndex = 0;

                    // テキストボックスの下に配置
                    var point = _textBox.Parent.PointToClient(
                        _textBox.PointToScreen(new Point(0, _textBox.Height)));

                    _suggestionList.Left = point.X;
                    _suggestionList.Top = point.Y;
                    _suggestionList.Width = _textBox.Width;

                    // 最大高さを設定（5項目まで）
                    int itemHeight = _suggestionList.ItemHeight;
                    int maxItems = Math.Min(5, _suggestionList.Items.Count);
                    _suggestionList.Height = (itemHeight * maxItems) + 4; // 境界線の余白

                    _suggestionList.BringToFront();
                    _suggestionList.Visible = true;
                }
                else
                {
                    HideSuggestions();
                }
            }
            else
            {
                HideSuggestions();
            }
        }

        private void HideSuggestions()
        {
            _suggestionList.Visible = false;
        }
    }
}

